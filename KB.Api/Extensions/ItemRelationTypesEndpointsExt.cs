using MediatR;
using KB.Core.Handlers.ItemRelationTypes;


namespace KB.Api.Extensions {
  public static class ItemRelationTypesEndpointsExt {
    public static WebApplication MapItemRelationTypesEndpoints(this WebApplication app) {
      var group = app.MapGroup("/api/item-relation-type").WithTags("ItemRelationType");
      
      group.MapGet("/", async ([AsParameters] GetItemRelationTypesQuery query, IMediator mediator) => {
             var result = await mediator.Send(query);
             return Results.Ok(result);
      }).WithName("GetItemRelationTypes").WithDescription("Retrieves an item relation types via filters.");
    
      group.MapPost("/", async ([AsParameters] CreateItemRelationTypeCommand command, IMediator mediator) => {
          var result = await mediator.Send(command);
          return Results.Created($"/api/item-relation-type/{result.Id}", result);
      }).WithName("CreateItemRelationType").WithDescription("Creates a new item relation type.");

      group.MapGet("/{id:int}", async (int id, IMediator mediator) => {
        var query = new GetItemRelationTypesQuery(Id: id, Relation: null);
        var result = await mediator.Send(query);
        if (result == null || !result.Any()) {
          return Results.NotFound();
        }
        return Results.Ok(result.First());
      })
      .WithName("GetItemRelationTypeById")
      .WithDescription("Retrieves a single item type by ID.");

      group.MapPut("/{Id}", async (int Id, UpdateItemRelationTypeCommand command, IMediator mediator) => {
          if (Id != command.Id) {
            return Results.BadRequest("ID in URL does not match ID in body.");
          }
          var result = await mediator.Send(command);
          return Results.Ok(result);
      }).WithName("UpdateItemRelationType").WithDescription("Updates an existing item relation type.");
    
      group.MapDelete("/{Id}", async (int Id, IMediator mediator) => {
          var command = new DeleteItemRelationTypeCommand(Id);
          await mediator.Send(command);
          return Results.NoContent();
      }).WithName("DeleteItemRelationType").WithDescription("Deletes an item relation type by ID.");

      return app;
    }
  }
}
