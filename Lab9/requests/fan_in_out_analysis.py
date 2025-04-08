import json
from collections import defaultdict

# Load the JSON file
with open('dependencies.json', 'r') as file:
    data = json.load(file)

imports_by_module = {}
for module_name, module_info in data.items():
    imports_by_module[module_name] = set(module_info.get('imports', []))

fan_in = defaultdict(set)
fan_out = defaultdict(set)

for module, imports in imports_by_module.items():
    for imported_module in imports:
        if imported_module in data and imported_module != module:
            fan_out[module].add(imported_module)
            fan_in[imported_module].add(module)

# Write results to a file
with open('fan_in_out_report.txt', 'w') as report:
    report.write("Fan-In and Fan-Out per module:\n\n")
    for module in sorted(data):
        report.write(f"Module: {module}\n")
        report.write(f"  Fan-In  = {len(fan_in[module])} (Used by: {sorted(fan_in[module])})\n")
        report.write(f"  Fan-Out = {len(fan_out[module])} (Uses:    {sorted(fan_out[module])})\n\n")

print("Fan-In and Fan-Out report saved to 'fan_in_out_report.txt'")
