from base_parser import BAASParser
import sys

input = sys.argv[1]
parser = BAASParser()
output = parser.parse(input)

print(output)