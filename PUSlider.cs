

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

public partial class PUSlider : PUSliderBase {

	PUImage handle;

	Slider slider;

	public override void gaxb_init ()
	{
		base.gaxb_init ();

		if (titleExists == false) {
			gameObject.name = "<Slider/>";
		}

		gameObject.AddComponent<Slider> ();
		slider = gameObject.GetComponent<Slider> ();

		handle = new PUImage (handleResourcePath, Color.white);
		handle.SetFrame (0, 0, 40, 0, 0.5f, 0.5f, "stretch,right");
		handle.LoadIntoPUGameObject (this);

		if (onValueChanged != null) {
			slider.onValueChanged.AddListener ((v) => {
				NotificationCenter.postNotification (Scope (), this.onValueChanged, NotificationCenter.Args("sender", this, "value", v));
			});
		}

		slider.targetGraphic = handle.image;
		slider.handleRect = handle.rectTransform;
	}

}
