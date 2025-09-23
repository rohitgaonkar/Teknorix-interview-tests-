﻿[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

public class SwaggerConfig
{
    public static void Register()
    {
        GlobalConfiguration.Configuration
            .EnableSwagger(c => c.SingleApiVersion("v1", "Teknorix Jobs API"))
            .EnableSwaggerUi();
    }
}
