using MediatR;
using KB.Core.Handlers.ItemTypes;

namespace KB.Api.Extensions {
  public static class ItemTypesEndpointsExt {
    public static WebApplication MapItemTypesEndpoints(this WebApplication app) {
      var group = app.MapGroup("/api/item-type").WithTags("ItemType");
         group.MapGet("/{Id}", async ([AsParameters] GetItemTypesQuery query, IMediator mediator) => {
              var result = await mediator.Send(query);
              return Results.Ok(result);
         }).WithName("GetItemType").WithDescription("Retrieves an item type by ID.");
    
         group.MapPost("/", async ([AsParameters] CreateItemTypeCommand command, IMediator mediator) => {
               var result = await mediator.Send(command);
               return Results.Created($"/api/item-type/{result.Id}", result);
          }).WithName("CreateItemType").WithDescription("Creates a new item type.");
    
         group.MapPut("/{Id}", async (int Id, UpdateItemTypeCommand command, IMediator mediator) => {
               if (Id != command.Id) {
                 return Results.BadRequest("ID in URL does not match ID in body.");
               }
               var result = await mediator.Send(command);
               return Results.Ok(result);
          }).WithName("UpdateItemType").WithDescription("Updates an existing item type.");
    
         group.MapDelete("/{Id}", async (int Id, IMediator mediator) => {
               var command = new DeleteItemTypeCommand(Id);
               await mediator.Send(command);
               return Results.NoContent();
          }).WithName("DeleteItemType").WithDescription("Deletes an item type by ID.");
       return app;
    }
  }
}
