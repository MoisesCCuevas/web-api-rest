public class TimeMiddleware {
    // request delegate is a function that can process an HTTP request
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest) {
      next = nextRequest;
    }

    // Invoke method is called when the middleware is executed
    public async Task Invoke(HttpContext context) {
        // call the next middleware in the pipeline
        await next(context);
        // check if the query string contains the key "showTime"
        if (context.Request.Query.Any(p => p.Key == "showTime")) {
          await context.Response.WriteAsync($"The time is: {DateTime.Now}");
        }
        //await next(context);
    }

    
}

// Extension method used to add the middleware to the HTTP request pipeline
public static class TimeMiddlewareExtension {
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}