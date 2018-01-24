
# Notes(gb): 

* The ship now calibrates harshly at start (nose of ship dives down and then jumps back). 
Try to keep ship steady at its level on start.

* Try limit Raycasts to only search in a specific layer (use a layerMask).

* Make sure to limit engine calls: store in local/class variables.
```csharp
// good:
Vector3 pos = transform.position; // store in local variable, reduces engine calls
pos += new Vector3(pos.x / 2, pos.y / 2, pos.z + 10);
pos += Vector3.forward;
transform.position = pos; // assign back to position when all calculations are done

// bad: keeps using calls into the Unity engine = unnecessary CPU overhead + harder to read.
transform.position += new Vector3(transform.position.x, transform.position.y, transform.position.z);
transform.position += Vector3.forward; 
```

* Prefer commenting sections over extracting them. 
Whenever you have a function, it implicitly says it can be called from anywhere inside the class. 
Never have a function do something that happens in only one place.
(Look at RotateShip, MoveShip, ...)


* Avoid hardcoding values. If you do make sure you comment it with `// @Hardcoded` so we can search for it later.
If harcoded, try make it a constant, so we know what we are reading.

```csharp
// @Hardcoded
const float distanceFromGround = 0.02;
if ( midHeight - frontHeight > distanceFromGround ) { }
```


* Constrain scope of your variables. 
Don't leak out data where it doesn't need to be. 
Don't keep data around longer than it needs to be.

