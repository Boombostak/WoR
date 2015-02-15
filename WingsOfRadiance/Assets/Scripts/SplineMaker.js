@script ExecuteInEditMode()
#pragma strict
 
public var controlPoints : GameObject[] = new GameObject[3];
public var color : Color = Color.white;
public var width : float = 0.2;
public var numberOfPoints : int = 20;
 
function Start() 
{
    // initialize line renderer component
    var lineRenderer : LineRenderer = 
       GetComponent(LineRenderer);
    if (null == lineRenderer)
    {
        gameObject.AddComponent(LineRenderer);
    }
    lineRenderer = GetComponent(LineRenderer);
    lineRenderer.useWorldSpace = true;
    lineRenderer.material = new Material(
       Shader.Find("Particles/Additive"));
}
 
function Update() 
{
    // check parameters and components
    var lineRenderer : LineRenderer = 
       GetComponent(LineRenderer);
    if (null == lineRenderer || controlPoints == null 
       || controlPoints.length < 2)
    {
        return; // not enough points specified
    } 
 
    // update line renderer
    lineRenderer.SetColors(color, color);
    lineRenderer.SetWidth(width, width);
    if (numberOfPoints < 2)
    {
        numberOfPoints = 2;
    }
    lineRenderer.SetVertexCount(numberOfPoints * 
       (controlPoints.length - 1));
 
    // loop over segments of spline
    var p0 : Vector3;
    var p1 : Vector3;
    var m0 : Vector3;
    var m1 : Vector3;
    for (var j : int = 0; j < controlPoints.length - 1; j++)
    {
        // check control points
       if (controlPoints[j] == null || 
          controlPoints[j + 1] == null ||
          (j > 0 && controlPoints[j - 1] == null) ||
          (j < controlPoints.length - 2 && 
          controlPoints[j + 2] == null))
    {
          return;  
    }
// determine control points of segment
p0 = controlPoints[j].transform.position;
p1 = controlPoints[j + 1].transform.position;
if (j > 0) 
{
    m0 = 0.5 * (controlPoints[j + 1].transform.position 
    - controlPoints[j - 1].transform.position);
}
else
{
    m0 = controlPoints[j + 1].transform.position 
    - controlPoints[j].transform.position;
}
if (j < controlPoints.length - 2)
{
    m1 = 0.5 * (controlPoints[j + 2].transform.position 
    - controlPoints[j].transform.position);
}
else
{
    m1 = controlPoints[j + 1].transform.position 
    - controlPoints[j].transform.position;
}   
 
// set points of Hermite curve
var position : Vector3;
var t : float; 
var pointStep : float = 1.0 / numberOfPoints;
if (j == controlPoints.length - 2)
{
    pointStep = 1.0 / (numberOfPoints - 1.0);
    // last point of last segment should reach p1
}  
for(var i : int = 0; i < numberOfPoints; i++) 
{
   t = i * pointStep;
   position = (2.0*t*t*t - 3.0*t*t + 1.0) * p0  
      + (t*t*t - 2.0*t*t + t) * m0
      + (-2.0*t*t*t + 3.0*t*t) * p1
      + (t*t*t - t*t) * m1;
   lineRenderer.SetPosition(i + j * numberOfPoints, 
      position);
}
}
}