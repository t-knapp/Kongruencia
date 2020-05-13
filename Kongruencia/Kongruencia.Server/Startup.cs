using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using HotChocolate;
using HotChocolate.AspNetCore;
using MongoDB.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MediatR;
using Kongruencia.Server.GraphQL;
using HotChocolate.AspNetCore.GraphiQL;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Subscriptions;
using Kongruencia.Server.GraphQL.Schema;

namespace Kongruencia.Server {

    public class Startup {

        public IConfiguration Configuration { get; }

        public Startup( IConfiguration configuration ) => Configuration = configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services ) {

            services
                .AddOptions()
                .AddOptions<MongoDBOptions>().Bind( Configuration.GetSection( "MongoDB" ) );

            services
                .AddSingleton<DB>( s => {
                    var options = s.GetService<IOptions<MongoDBOptions>>();
                    return new DB( options.Value.Database, options.Value.Address, options.Value.Port );
                } )
                .AddSingleton( typeof( IMongoCollection<> ), typeof( MongoCollection<> ) );

            services.AddAutoMapper( typeof( Startup ) );
            services.AddMediatR( typeof( Startup ) );

            //services.AddInMemorySubscriptionProvider();
            services.AddGraphQL( sp => SchemaBuilder.New()
                .AddServices( sp )
                .AddAuthorizeDirectiveType()

                .AddQueryType<Query>()
                .AddMutationType<Mutation>()

                .AddType<ProductType>()
                //.AddSubscriptionType<SubscriptionType>()

                .Create()
            );

            services.AddControllers();
            services.AddMvcCore()
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env ) {

            if( env.IsDevelopment() ) 
                app.UseDeveloperExceptionPage();
            else
                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication()
               .UseAuthorization()
               .UseSession();

            app.UseWebSockets()
               .UseGraphQL()
               .UseGraphiQL();

            app.UseEndpoints( endpoints => {
                endpoints.MapControllers();
            } );
        }
    }
}
