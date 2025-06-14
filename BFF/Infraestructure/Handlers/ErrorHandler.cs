using Microsoft.AspNetCore.Mvc;

public static class ErrorHandler
{
    public static IActionResult Handle(Exception ex)
    {
        return ex switch
        {
            AppHttpException appEx => appEx.StatusCode switch
            {
                400 => new BadRequestObjectResult(new { code = 400, msg = appEx.Message }),
                404 => new NotFoundObjectResult(new { code = 404, msg = appEx.Message }),
                _ => new ObjectResult(new { code = appEx.StatusCode, msg = appEx.Message }) { StatusCode = appEx.StatusCode }
            },
            _ => new ObjectResult(new { msg = ex.Message }) { StatusCode = 500 }
        };
    }
}