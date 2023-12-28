using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.Query.Expressions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm.Csdl;
using Microsoft.OData.Edm.Vocabularies;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.UriParser;
using System.Linq.Expressions;
using System.Reflection;

namespace TestODataProject
{
    public static class ODataModel
    {
        private static EdmModel? _edmModel;
        private static EdmModel EdmModel => _edmModel ?? CreateEdmModel();
        public static ODataOptions AddODataModel(this ODataOptions? options)
        {
            options ??= new ODataOptions();
            options.EnableQueryFeatures(3000);
            options.AddRouteComponents(routePrefix: "odata", model: EdmModel, services =>
            {
                services.AddSingleton<ISearchBinder, SearchBinder>();
                services.AddSingleton<ISelectExpandBinder, CustomSelectExpandBinder>();
                services.AddSingleton<ODataBatchHandler>(GetBatchHandler());
            });
            options.RouteOptions.EnableNonParenthesisForEmptyParameterFunction = true;
            options.EnableAttributeRouting = true;
            return options;
        }

        private static DefaultODataBatchHandler GetBatchHandler()
        {
            var batchHandler = new DefaultODataBatchHandler
            {
                MessageQuotas = { MaxNestingDepth = 2, MaxOperationsPerChangeset = 10, MaxReceivedMessageSize = 100 }
            };

            return batchHandler;
        }

        private static EdmModel CreateEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder
            {
                Namespace = "DataPlatform",
            };
            ODataMasModel.AddMasModels(modelBuilder);            

            _edmModel = (EdmModel)modelBuilder.GetEdmModel();

            foreach (var set in modelBuilder.EntitySets)
            {

                var attributeList = set.ClrType.GetCustomAttributes<ODataAnnotationAttribute>();
                var edmEntityType = _edmModel.FindDeclaredEntitySet(set.Name).EntityType();
                CreateAndAddVocabularyAnnotation(_edmModel, attributeList, edmEntityType);
                foreach (var property in set.ClrType.GetProperties().Where(x => x.IsDefined(typeof(ODataAnnotationAttribute))))
                {
                    var propertyAttributeList = property.GetCustomAttributes<ODataAnnotationAttribute>();
                    var propertyTarget = edmEntityType.FindProperty(property.Name);
                    CreateAndAddVocabularyAnnotation(_edmModel, propertyAttributeList, propertyTarget);
                }
            }

            ODataMasModel.AddMasNavigationLinks(_edmModel);

            return _edmModel;
        }

        private static void CreateAndAddVocabularyAnnotation(EdmModel model, IEnumerable<ODataAnnotationAttribute> attributes, IEdmVocabularyAnnotatable target)
        {
            if (attributes?.Count() < 1) return;

            foreach (var attribute in attributes!)
            {
                try
                {
                    var (term, expression) = AttributeParseHelper(attribute);
                    var annotation = new EdmVocabularyAnnotation(target, term, expression);
                    annotation.SetSerializationLocation(_edmModel, EdmVocabularyAnnotationSerializationLocation.Inline);
                    model.AddVocabularyAnnotation(annotation);
                }
                catch (Exception ex)
                {
                    continue;
                }

            }
        }

        private static (IEdmTerm term, IEdmExpression expression) AttributeParseHelper(ODataAnnotationAttribute attribute)
        {
            var description = ODataAnnotationEnumHelper.GetEnumDescription(attribute.Term);
            return (new EdmTerm(description.NameSpace, description.Name, EdmPrimitiveTypeKind.String),
                    GenerateEdmExpression(description.AnnotationType, attribute.Collection));
        }

        private static IEdmExpression GenerateEdmExpression(ODataAnnotationType annotationType, params string[] additionalInfo) => annotationType switch
        {
            ODataAnnotationType.Collection => new EdmCollectionExpression(additionalInfo.Select(x => new EdmStringConstant(x))),
            //ODataAnnotationType.EnumMember => throw new NotImplementedException(),
            ODataAnnotationType.String => new EdmStringConstant(additionalInfo.FirstOrDefault()),
            ODataAnnotationType.Bool => new EdmBooleanConstant(BoolParser(additionalInfo)),
            _ => throw new NotImplementedException()
        };

        private static bool BoolParser(string[] collection)
        {
            try
            {
                return bool.Parse(collection.First());
            }
            catch
            {
                return true;
            }
        }
    }

    public class CustomSelectExpandBinder : SelectExpandBinder
    {
        public CustomSelectExpandBinder(IFilterBinder filterBinder, IOrderByBinder orderByBinder)
            : base(filterBinder, orderByBinder)
        {
        }

        // 
        public override Expression CreatePropertyValueExpression(QueryBinderContext context, IEdmStructuredType elementType, IEdmProperty edmProperty, Expression source, FilterClause filterClause, ComputeClause computeClause = null)
        {
            if (edmProperty.Type.IsCollection())
            {
                IEdmModel model = context.Model;
                if (string.Equals(edmProperty.Name, "flags", StringComparison.OrdinalIgnoreCase))
                {
                    PropertyInfo emailsProperty = source.Type.GetProperty("flags_string");
                    Expression propertyValue = Expression.Property(source, emailsProperty);

                    return propertyValue;
                }
            }


            return base.CreatePropertyValueExpression(context, elementType, edmProperty, source, filterClause, computeClause);
        }
    }
}
