using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Hladir.CSharp.Standard;
using R5T.Koping.Standard;
using R5T.Lombardy.Standard;
using R5T.Solgene;

using R5T.Soltana.Default;


namespace R5T.Soltana.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IVisualStudioSolutionFileOperator"/> service.
        /// Allows specifying the <see cref="IVisualStudioSolutionFileGenerator"/>, to allow using either VS2017 or VS2019.
        /// </summary>
        public static IServiceCollection AddVisualStudioSolutionFileOperator(this IServiceCollection services,
            ServiceAction<IVisualStudioSolutionFileGenerator> addSolutionFileGenerator)
        {
            services
                .AddDefaultVisualStudioSolutionFileOperator(
                    addSolutionFileGenerator,
                    services.AddVisualStudioSolutionFolderProjectTypeGuidProviderAction(),
                    services.AddVisualStudioProjectFileNameConventionsAction(),
                    services.AddStringlyTypedPathOperatorAction())
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IVisualStudioSolutionFileOperator"/> service.
        /// Allows specifying the <see cref="IVisualStudioSolutionFileGenerator"/>, to allow using either VS2017 or VS2019.
        /// </summary>
        public static ServiceAction<IVisualStudioSolutionFileOperator> AddVisualStudioSolutionFileOperatorAction(this IServiceCollection services,
            ServiceAction<IVisualStudioSolutionFileGenerator> addSolutionFileGenerator)
        {
            var serviceAction = new ServiceAction<IVisualStudioSolutionFileOperator>(() => services.AddVisualStudioSolutionFileOperator(
                addSolutionFileGenerator));
            return serviceAction;
        }
    }
}
