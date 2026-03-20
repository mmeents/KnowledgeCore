using MediatR;
using KB.Core.Handlers.ItemRelations;

namespace KB.Api.Extensions {
  public static class ItemRelationsEndpointsExt {

      public static WebApplication MapItemRelationsEndpoints(this WebApplication app) {
        var group = app.MapGroup("/api/item-relation").WithTags("ItemRelation");

         group.MapGet("/", async ([AsParameters] GetItemRelationsQuery query, IMediator mediator) => {
            var result = await mediator.Send(query);
            return Results.Ok(result);
         }).WithName("GetItemRelation").WithDescription("Retrieves items via filters.");

         group.MapGet("/{Id}", async (int Id, IMediator mediator) => {
             var query = new GetItemRelationsQuery( Id, ItemId:null, ToItemId:null, RelationTypeId:null );
             var result = await mediator.Send(query);
             if (result == null || !result.Any()) {
                 return Results.NotFound();
             }
             return Results.Ok(result.First());
         }).WithName("GetItemRelationById").WithDescription("Retrieves an item relation by ID.");

         group.MapPost("/", async (CreateItemRelationCommand command, IMediator mediator) => {
             var result = await mediator.Send(command);
             return Results.Created($"/api/item-relation/{result.Id}", result);
         }).WithName("CreateItemRelation").WithDescription("Creates a new item relation.");

         group.MapPut("/{Id}", async (int Id, UpdateItemRelationCommand command, IMediator mediator) => {
             if (Id != command.Id) {
                 return Results.BadRequest("ID in URL does not match ID in body.");
             }
             var result = await mediator.Send(command);
             return Results.Ok(result);
         }).WithName("UpdateItemRelation").WithDescription("Updates an existing item relation.");

         group.MapDelete("/{Id}", async (int Id, IMediator mediator) => {
             var command = new DeleteItemRelationCommand(Id);
             await mediator.Send(command);
             return Results.NoContent();
         }).WithName("DeleteItemRelation").WithDescription("Deletes an item relation by ID.");

      return app;
      }

  }
}
