// 
// ITextTemplatingEngineHost.cs
//  
// Author:
//       Mikayla Hutchinson <m.j.hutchinson@gmail.com>
// 
// Copyright (c) 2009-2010 Novell, Inc. (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo (typeof (Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngine))]
[assembly: TypeForwardedTo (typeof (Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost))]
[assembly: TypeForwardedTo (typeof (Microsoft.VisualStudio.TextTemplating.ITextTemplatingSession))]
[assembly: TypeForwardedTo (typeof (Microsoft.VisualStudio.TextTemplating.ITextTemplatingSessionHost))]

namespace Microsoft.VisualStudio.TextTemplating
{
	public interface IRecognizeHostSpecific
	{
		void SetProcessingRunIsHostSpecific (bool hostSpecific);
		bool RequiresProcessingRunIsHostSpecific { get; }
	}

	public interface IDirectiveProcessor
	{
		CompilerErrorCollection Errors { get; }
		bool RequiresProcessingRunIsHostSpecific { get; }

		void FinishProcessingRun ();
		string GetClassCodeForProcessingRun ();
		string[] GetImportsForProcessingRun ();
		string GetPostInitializationCodeForProcessingRun ();
		string GetPreInitializationCodeForProcessingRun ();
		string[] GetReferencesForProcessingRun ();
		CodeAttributeDeclarationCollection GetTemplateClassCustomAttributes ();  //TODO
		void Initialize (ITextTemplatingEngineHost host);
		bool IsDirectiveSupported (string directiveName);
		void ProcessDirective (string directiveName, IDictionary<string, string> arguments);
		void SetProcessingRunIsHostSpecific (bool hostSpecific);
		void StartProcessingRun (CodeDomProvider languageProvider, string templateContents, CompilerErrorCollection errors);
	}
}
