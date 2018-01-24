
# Notes(gb): 

* The ship now calibrates harshly at start (nose of ship dives down and then jumps back). 
Try to keep ship steady at its level on start.

* Make sure to limit engine calls: store in local/class variables.

* Prefer commenting sections over extracting them. Whenever you have a function, it implicitly says it can be called from anywhere inside the class. Never have a function do something that happens in only one place.

* Avoid hardcoding values. If you do make sure you comment it with `// @Hardcoded` so we can search for it later.
Also make it a constant, so we know what we are reading:

* Constrain scope of your variables. 
Don't leak out data where it doesn't need to be. 
Don't keep data around longer than it needs to be.


