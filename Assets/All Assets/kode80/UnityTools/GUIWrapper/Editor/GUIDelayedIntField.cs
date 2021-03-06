//  Copyright (c) 2016, Ben Hopkins (kode80)
//  All rights reserved.
//  
//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:
//  
//  1. Redistributions of source code must retain the above copyright notice, 
//     this list of conditions and the following disclaimer.
//  
//  2. Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//  
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
//  EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
//  MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL 
//  THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
//  SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT 
//  OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
//  HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
//  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
//  EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace kode80.GUIWrapper
{
	public class GUIDelayedIntField : GUIBase 
	{
		private int _previousValue;
		public int previousValue { get { return _previousValue; } }
		public int value;
		public int minValue;
		public int maxValue;

		private GUIContent _content;
		public GUIContent content { get { return _content; } }

		public GUIDelayedIntField( GUIContent content, int value=0, int minValue=0, int maxValue=0, OnGUIAction action=null)
		{
			this.value = value;
			_previousValue = value;
			this.minValue = minValue;
			this.maxValue = maxValue;

			_content = content;
			if( action != null)
			{
				onGUIAction += action;
			}
		}

		protected override void CustomOnGUI ()
		{
			int newValue = EditorGUILayout.DelayedIntField( _content, value);

			if( newValue != value && newValue >= minValue && newValue <= maxValue)
			{
				_previousValue = value;
				value = newValue;
				CallGUIAction();
			}
		}
	}
}
