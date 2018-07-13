# demo-c#-one

## description
various demos to evaluate / test the language and aspects of its ecosystem

### threading
uniform split of work load across multiple threads

### sql<->linq
sqlmetal (formally dbmetal) generation of class from db schema

## dependencies
refer to `./refs` file for required assembly references
- mono (no ms cruft here!)
- postgresql

## usage
use `_c#` script

### build
`> ./_c# demo-c#-one compile`

specification of the desired binary name is optional

`> ./_c# compile`

### run
`> ./_c# run`

### debugging
using *sdb*, insert `Debugger.Break();` at the appropriate code line (requires `using System.Diagnostics`)

`> sdb "run demo-c#-one.exe`

