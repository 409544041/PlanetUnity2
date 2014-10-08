/* Copyright (c) 2012 Small Planet Digital, LLC
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files 
 * (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, 
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


using UnityEngine;
using UnityEngine.UI;

public partial class PUScrollRect : PUScrollRectBase {

	public GameObject contentObject;
	public ScrollRect scroll;
	public CanvasRenderer canvasRenderer;

	public override void gaxb_init ()
	{
		gameObject = new GameObject ("<ScrollRect/>", typeof(RectTransform));
		gameObject.AddComponent<CanvasRenderer> ();
		gameObject.AddComponent<ScrollRect> ();

		scroll = gameObject.GetComponent<ScrollRect> ();
		canvasRenderer = gameObject.GetComponent<CanvasRenderer> ();



		if (inertiaExists) {
			scroll.inertia = inertia;
		}
		if (horizontalExists) {
			scroll.horizontal = horizontal;
		}
		if (verticalExists) {
			scroll.vertical = vertical;
		}
		if (scrollWheelSensitivityExists) {
			scroll.scrollSensitivity = scrollWheelSensitivity;
		}
	}

	public void CalculateContentSize()
	{
		RectTransform myRectTransform = (RectTransform)contentObject.transform;

		if (contentObject.transform.childCount == 0) {
			myRectTransform.sizeDelta = new Vector2((gameObject.transform as RectTransform).rect.width, 0);
			return;
		}

		// if contentSize does not exist, run through planet children and calculate a content size
		float minX = 999999, maxX = -999999;
		float minY = 999999, maxY = -999999;

		foreach (RectTransform t in contentObject.transform) {

			float tMinX = t.GetMinX ();
			float tMaxX = t.GetMaxX ();
			float tMinY = t.GetMinY ();
			float tMaxY = t.GetMaxY ();
			
			if (tMinX < minX)
				minX = tMinX;
			if (tMinY < minY)
				minY = tMinY;

			if (tMaxX > maxX)
				maxX = tMaxX;
			if (tMaxY > maxY)
				maxY = tMaxY;
		}
			
		myRectTransform.sizeDelta = new Vector2 (maxX - minX, maxY - minY);
	}

	public void SetContentSize(float w, float h)
	{
		RectTransform myRectTransform = (RectTransform)contentObject.transform;
		myRectTransform.sizeDelta = new Vector2(w,h);
	}
		
	public override void gaxb_complete()
	{
		// 0) create a content game object to place all of our children into
		contentObject = new GameObject ("ScrollRectContent", typeof(RectTransform));

		for(int i = gameObject.transform.childCount-1; i >= 0; i--){
			Transform t = gameObject.transform.GetChild (i);
			t.SetParent (contentObject.transform, false);
		}
		contentObject.transform.SetParent (gameObject.transform);

		contentObject.layer = LayerMask.NameToLayer ("UI");

		// 1) point the scroll rect at our content object
		scroll.content = (RectTransform)contentObject.transform;

		// 2) set the size of the contentObject to the largest rect containing all of our children
		CalculateContentSize ();

		// 3) fix the position of the contentObject so it the scroll is at the top...
		RectTransform myRectTransform = (RectTransform)contentObject.transform;
		myRectTransform.pivot = new Vector2 (0, 1);
		myRectTransform.anchorMin = myRectTransform.anchorMax = new Vector2 (0, 1);
		myRectTransform.anchoredPosition = Vector2.zero;

		base.gaxb_complete ();
	}

}
