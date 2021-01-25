import json
import sys

PATH_TRUFFLE_WK = sys.argv[1]
truffleFile = json.load(open(PATH_TRUFFLE_WK + sys.argv[2]))

abi = truffleFile['abi']
address = truffleFile['networks']['5777']['address']

print(abi)
print(address)