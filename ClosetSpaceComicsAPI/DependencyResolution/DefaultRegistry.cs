// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ClosetSpaceComicsAPI.DependencyResolution {
	using ClosetSpaceComics.Domain.Catalog;
	using ClosetSpaceComics.Domain.User;
	using ClosetSpaceComics.Service.Repositories;
	using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
			//For<IExample>().Use<Example>();

			//For<IIssueRepository>().Use<IssueRepository>();
			//For<IPublisherRepository>().Use<PublisherRepository>();
			For<IMigrationRepository>().Use<MigrationRepository>();

			For<ICatalogContext>().Use<CatalogContext>();
			For<IPublisherFactory>().Use<PublisherFactory>();
			For<ITitleFactory>().Use<TitleFactory>();
			For<IIssueFactory>().Use <IssueFactory>();
			For<ILocationFactory>().Use<LocationFactory>();
			For<IPurchaseFactory>().Use<PurchaseFactory>();

			For<IPublisherContext>().Use<PublisherContext>();
			For<ITitleContext>().Use<TitleContext>();
			For<IIssueContext>().Use<IssueContext>();
			For<IUserContext>().Use<UserContext>();
			For<ILocationContext>().Use<LocationContext>();
			For<IPurchaseContext>().Use<PurchaseContext>();

			For<IUserQueryRepository>().Use<UserQueryRepository>();
			For<IPublisherQueryRepository>().Use<PublisherQueryRepository>();
			For<ITitleQueryRepository>().Use<TitleQueryRepository>();
			For<IIssueQueryRepository>().Use<IssueQueryRepository>();
			For<IIssueCommandRepository>().Use<IssueCommandRepository>();
			For<ITitleCommandRepository>().Use<TitleCommandRepository>();
			For<ILocationQueryRepository>().Use<LocationQueryRepository>();
			For<IPurchaseQueryRepository>().Use<PurchaseQueryRepository>();
			For<IPurchaseCommandRepository>().Use<PurchaseCommandRepository>();
		}

		#endregion
	}
}