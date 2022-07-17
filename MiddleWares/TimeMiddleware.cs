using System.Collections.Immutable;
public class TimeMiddleware
{
    readonly RequestDelegate next;
    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next =  nextRequest;    
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        await next(context);        
        //El request que tenga el parametro "time" le vamos a retornar la hora del servidor
        if(context.Request.Query.Any(p => p.Key == "time"))
        {
            //Devolvemos la hora del servidor sobre el request
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }
}

public static class TimeMiddlewareExtension
{
    //Recibimos el IApplicationBuilder y lo retornamos con el nuevo middleware ya agregado.
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        //Recibimos el contexto actual del builder, tomamos el builder y agregamos el middleware creado y retornamos
        //que siga con el siguiente middleware de la secuencia
        return builder.UseMiddleware<TimeMiddleware>();
    }
}