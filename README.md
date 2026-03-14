# High-Performance Excel to PostgreSQL Migrator (.NET 10)

A blazing-fast Console Application built with **.NET 10** to migrate large-scale Excel data (1M+ records) into **PostgreSQL** using the ELT (Extract, Load, Transform) pattern.

## 🚀 Overview

Migrating millions of records from Excel can be memory-intensive and slow. This tool solves that by using a **Streaming Reader** to keep memory usage low and **PostgreSQL Binary COPY** for ultra-fast database ingestion.

### Key Features:
- **Low Memory Footprint**: Uses `ExcelDataReader` to stream data instead of loading entire files into RAM.
- **High-Speed Ingestion**: Utilizes `Npgsql` Binary COPY, bypassing the overhead of standard SQL `INSERT` statements.
- **ELT Pattern**: Loads raw data into **Unlogged Staging Tables** first, allowing for faster validation and transformation within the database.
- **Clean Configuration**: Uses `Microsoft.Extensions.Configuration` for secure and flexible setting management.

---

## 🛠️ Prerequisites

- **.NET 10 SDK**
- **PostgreSQL 15+**
- **Excel Files** (.xlsx) with the required structure (Individu & Keluarga).

---

## 📦 Dependencies

The following NuGet packages are required for this project:

```bash
# Core Configuration
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Configuration.FileExtensions
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables

# Database & Excel Processing
dotnet add package Npgsql
dotnet add package ExcelDataReader