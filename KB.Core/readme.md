## Knowledge Base Core aka Kb.Core

This is base database core for Items and Relations knowledge base targeting MS Sql Server via Ef Core. you will need to add package and then build a new dbContext inheriting from KbDbContext to build on top. 

### Installation
```bash
dotnet add package KB.Core
```

### Versions
- 1.0.0: Initial release with basic Item and Relation entities, and KbDbContext for MS Sql Server using Ef Core.
- 1.0.3: Minor updates
- 1.0.4: Added nullable relation in ItemRelation -- need to add migration after upgrade.
