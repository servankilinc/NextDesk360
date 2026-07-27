# Development Rules & Architectural Guidelines

To maintain architectural consistency and avoid unnecessary modifications, the following guidelines must be followed:

## 1. AutoMapper & Data Mapping
- **Explicit Instruction Only**: Do not automatically add AutoMapper configurations in `MappingProfiles.cs` unless mapping is explicitly requested, or it is the standard architectural pattern for new entities/DTOs.
- **Manual Projections**: When doing query projections, prefer manual Select projections or existing extension methods first if it reduces mapping configuration overhead.
- **DTO Placement**: Ensure DTOs are placed in their respective `ExpressDesk360.Model/Dtos/{EntityName}/Queries` or `Commands` directories.

## 2. Code Modifiability & Consistency
- **Minimal Code Changes**: Keep edits as focused and minimal as possible. Do not refactor unrelated files or add features not explicitly requested by the user.
- **No Unused Entities**: Do not create helper classes, new service contracts, or controllers unless explicitly specified.
- **Naming Conventions**: Match existing repository naming conventions. Use English for code symbols (classes, properties) and follow the user's choice (e.g. Turkish) for UI text/labels.

## 3. UI and DataTable Rendering
- **DataTable Column Matching**: Always check if custom columns and rendering match the server-side sorting logic to prevent validation or ordering exceptions on name-projected columns.
