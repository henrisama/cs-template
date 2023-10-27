### How to create a migration

```bash
dotnet ef migrations add {{MigrationName}} -o Infra/Db/Migrations
```

By placing migrations within the Infra/Db directory, we ensure that our project is not only well-organized but also aligns with architectural best practices.

### How to run migration

```bash
dotnet ef database update
```
