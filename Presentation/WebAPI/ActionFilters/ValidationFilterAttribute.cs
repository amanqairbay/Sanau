using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.ActionFilters;

/// <summary>
/// Represents a filter attribute for validation.
/// </summary>
public class ValidationFilterAttribute : IActionFilter
{
    #region constructor

    public ValidationFilterAttribute() { }

    #endregion constructor

    /// <summary>
    /// Called after the action executes, before the action result.
    /// </summary>
    /// <param name="context">A context for action filters.</param>
    public void OnActionExecuted(ActionExecutedContext context) { }

    /// <summary>
    /// Called before the action executes, after model binding is complete.
    /// </summary>
    /// <param name="context">A context for action filters.</param>
    public void OnActionExecuting(ActionExecutingContext context) 
    {
        /* 
            We are using the context parameter to retrieve different values that we need inside this method. 
            With the RouteData.Values dictionary, we can get the values produced by routes on the current routing path. 
            Since we need the name of the action and the controller, we extract them from the Values dictionary.
        */
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        /*
            We use the ActionArguments dictionary to extract the DATA parameter that we send to the POST and PUT actions. 
        */
        var param = context.ActionArguments
            .SingleOrDefault(x => x.Value!.ToString()!.Contains("Dto"))
            .Value;

        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
            return; 
        }

        /*
            If the model is invalid, we create a new instance of the UnprocessableEntityObjectResult class and pass ModelState.
        */
        if (!context.ModelState.IsValid)
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
    }
}