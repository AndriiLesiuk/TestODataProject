using Microsoft.AspNetCore.OData.Edm;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.OData.Edm;

namespace TestODataProject
{
    public static class EdmModelHelper
    {
        public static void AddNavigationLinks(this IEdmModel edmModel, List<string> entityNames)
        {
            foreach (var entity in entityNames)
            {
                IEdmNavigationSource navigationSource = edmModel.FindDeclaredEntitySet(entity);
                IEdmEntityType elementType = navigationSource.EntityType();
                IEnumerable<IEdmEntityType> derivedTypes = edmModel.FindAllDerivedTypes(elementType).Cast<IEdmEntityType>();

                foreach (IEdmNavigationProperty navigationProperty in elementType.NavigationProperties())
                {
                    edmModel.HasNavigationPropertyLink(navigationSource, navigationProperty, new NavigationLinkBuilder((context, property) =>
                            context.GenerateNavigationPropertyLink(property, false), false));
                }

                foreach (IEdmEntityType derivedEntityType in derivedTypes)
                {
                    foreach (IEdmNavigationProperty navigationProperty in derivedEntityType.DeclaredNavigationProperties())
                    {
                        edmModel.HasNavigationPropertyLink(navigationSource, navigationProperty, new NavigationLinkBuilder((context, property) =>
                            context.GenerateNavigationPropertyLink(property, false), false));
                    }
                }
            }
        }
    }
}
