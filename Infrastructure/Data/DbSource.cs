namespace CSTemplate.Data;

public static class DbSource
{
  public static string ConnectionString { get; }

  static DbSource()
  {
    var host = Environment.GetEnvironmentVariable("POSTGRESQL_HOST");
    var username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
    var password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
    var database = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE");

    ConnectionString = $"Server={host};Database={database};User Id={username};Password={password};";
  }
}