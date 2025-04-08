import json
import pandas as pd

def load_dependencies(json_file):
    with open(json_file, 'r') as f:
        data = json.load(f)
    return {mod: set(info.get('imports', [])) for mod, info in data.items()}

def calculate_depths(deps):
    depths = {}

    def dfs(module, visited):
        if module in depths:
            return depths[module]
        if module in visited:
            print(f"Circular dependency detected: {module} in {visited}")
            return 0
        visited.add(module)
        max_depth = 0
        for dep in deps.get(module, []):
            max_depth = max(max_depth, 1 + dfs(dep, visited))
        visited.remove(module)
        depths[module] = max_depth
        return max_depth

    for module in deps:
        dfs(module, set())

    return depths

deps = load_dependencies("dependencies.json")
depths = calculate_depths(deps)

depth_df = pd.DataFrame([
    {"Module": mod, "Depth": depth}
    for mod, depth in depths.items()
])
depth_df.sort_values(by="Depth", ascending=False, inplace=True)
depth_df.to_csv("depths.csv", index=False)

print("Depth analysis saved to 'depths.csv'")