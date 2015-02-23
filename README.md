# crushfs
CrushFS - Merciless Density at Any Cost

CrushFS primary goal is to provide maximum density without regard for performance. A best effort will be made to make the file system as performant as possible, but not at the cost of density. It's purpose is to provide an easy-to-use 
and configurable filesystem for archive data. Do have you a LOT of redundant backups with folders upon folders of duplicate data? Don't worry about sorting through all of it. "Crush" it and reclaim your disk space!

CrushFS works by mounting CFS disk image as a drive letter of choosing. Beyond that it will manage all back-end compression, deduplication, and sizing of the backing file.