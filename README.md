# C# Learnings

This repository contains small C# projects used for learning and experimenting with language features and multithreading concepts.

## Structure

- `C# Learnings.sln` – main solution file
- `Multithreading/` – projects focusing on threading and synchronization primitives
  - `BasicSyntax/` – basic multithreading syntax and simple examples
  - `Assignment1/`, `Assignment2/` – practice exercises
  - `DivideAndConquer/` – examples of divide-and-conquer with tasks/threads
  - `GlobalMutexExample/` – global mutex usage
  - `NestedLocks/` – nested locking patterns
  - `ReaderWriterLock/` – reader/writer lock examples
  - `Semaphore/` – semaphore usage
  - `SignalingAutoResetEvent/` – examples with `AutoResetEvent`
  - `SignalingManualResetEvent/` – examples with `ManualResetEvent`
  - `ThreadSyncOverview/` – synchronization overview samples
  - `TwoWaySignaling/` – two-way thread signaling examples
  - `OffloadLongTasks/` – WinForms sample for offloading long-running tasks

## Prerequisites

- .NET SDK (6.0 or later recommended)
- Visual Studio 2022 or `dotnet` CLI

## How to Run

### Using Visual Studio

1. Open the solution file: `C# Learnings.sln`.
2. In Solution Explorer, right-click the project you want to run (for example, `BasicSyntax`).
3. Set it as **Startup Project**.
4. Press `F5` to run with debugging or `Ctrl+F5` to run without debugging.

### Using `dotnet` CLI

From the repository root:

```bash
# Restore all projects
dotnet restore

# Run a specific project, e.g., BasicSyntax
dotnet run --project "Multithreading/BasicSyntax/BasicSyntax.csproj"
```

Replace the project path with any of the other project folders listed above.

## Notes

These samples are for experimentation and learning. Feel free to modify, add new projects, or extend existing ones as you explore more C# and multithreading concepts.