import csv
import json
from pathlib import Path

pathlist = Path('.').glob('*.csv')

for path in pathlist:
    print(path)
    with open(path) as csvfile:
        rows = csv.DictReader(csvfile)
        open(str(path)[:-3]+'json', 'w').write(json.dumps(list(map(dict, rows))))

