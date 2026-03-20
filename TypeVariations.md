

      builder.HasData(
        new ItemType { Id = 1, Name = "Project", Description = "Recursive, can contain sub-projects" },
        new ItemType { Id = 2, Name = "Domain", Description = "Bounded context / problem area (DDD influence)" },
        new ItemType { Id = 3, Name = "Feature", Description = "Deliverable capability" },
        new ItemType { Id = 4, Name = "Component", Description = "Technical building block (service, lib, module)" },
        new ItemType { Id = 5, Name = "Requirement", Description = "Functional or non-functional" },
        new ItemType { Id = 6, Name = "Constraint", Description = "Things that limit decisions (time, budget, tech)" },
        new ItemType { Id = 7, Name = "Rule", Description = "A governing directive" },
        new ItemType { Id = 8, Name = "Scope", Description = "Boundary of applicability for rules" },
        new ItemType { Id = 9, Name = "Skill", Description = "Capability, knowledge area, or technology" },
        new ItemType { Id = 10, Name = "Role", Description = "Persona or team function (Dev, Architect, QA...)" },
        new ItemType { Id = 11, Name = "Decision", Description = "An ADR, a resolved choice with rationale" },
        new ItemType { Id = 12, Name = "Concept", Description = "Abstract idea or domain term (ubiquitous language)" },
        new ItemType { Id = 13, Name = "Standard", Description = "A convention or coding standard" },
        new ItemType { Id = 14, Name = "Technology", Description = "Language, framework, tool, platform" }
      );

      builder.HasData(
        new ItemRelationType { Id = 1, Relation = "Contains", Description = "Project → Feature, Project → Sub-Project, Domain → Concept" },
        new ItemRelationType { Id = 2, Relation = "BelongsTo", Description = "inverse of Contains (optional if you traverse IncomingRelations)" },
        new ItemRelationType { Id = 3, Relation = "DependsOn", Description = "Feature → Feature, Component → Component, Skill → Skill" },
        new ItemRelationType { Id = 4, Relation = "Implements", Description = "Feature → Requirement, Component → Feature" },
        new ItemRelationType { Id = 5, Relation = "Governs", Description = "Rule → Scope, Rule → Feature, Standard → Component" },
        new ItemRelationType { Id = 6, Relation = "AppliesTo", Description = "Rule → Domain, Constraint → Project" },
        new ItemRelationType { Id = 7, Relation = "Requires", Description = "Feature → Skill, Role → Skill"},
        new ItemRelationType { Id = 8, Relation = "Extends", Description = "Feature → Feature, Project → Project (inheritance/variation)" },
        new ItemRelationType { Id = 9, Relation = "Overrides", Description = "Rule → Rule (precedence)" },
        new ItemRelationType { Id = 10, Relation = "ConflictsWith", Description = "Constraint → Requirement, Rule → Rule" },
        new ItemRelationType { Id = 11, Relation = "SupersededBy", Description = "Decision → Decision (evolution over time)" },
        new ItemRelationType { Id = 12, Relation = "Exemplifies", Description = "Concept → Concept, Technology → Skill (concrete instance of)" },
        new ItemRelationType { Id = 13, Relation = "RelatedTo", Description = "Generic catch-all for weak associations" }
      );
