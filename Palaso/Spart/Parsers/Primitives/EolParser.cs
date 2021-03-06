// Spart License (zlib/png)
//
//
// Copyright (c) 2003 Jonathan de Halleux
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the authors be held liable for any damages arising from
// the use of this software.
//
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
// claim that you wrote the original software. If you use this software in a
// product, an acknowledgment in the product documentation would be
// appreciated but is not required.
//
// 2. Altered source versions must be plainly marked as such, and must not be
// misrepresented as being the original software.
//
// 3. This notice may not be removed or altered from any source distribution.
//
// Author: Jonathan de Halleuxusing System;
using Spart.Scanners;

namespace Spart.Parsers.Primitives
{

	/// <summary>
	/// Matches a CR, LF, or CR LF
	/// </summary>
	public class EolParser : TerminalParser
	{
		/// <summary>
		/// Inner parse method
		/// </summary>
		/// <param name="scanner">scanner</param>
		/// <returns>the match</returns>
		protected override ParserMatch ParseMain(IScanner scanner)
		{
			long offset = scanner.Offset;
			int len = 0;

			if (scanner.Peek() == '\r')    // CR
			{
				scanner.Read();
				++len;
			}

			if (scanner.Peek() == '\n')    // LF
			{
				scanner.Read();
				++len;
			}

			if (len>0)
			{
				ParserMatch m = ParserMatch.CreateSuccessfulMatch(scanner, offset, len);
				return m;
			}
			scanner.Seek(offset);
			return ParserMatch.CreateFailureMatch(scanner);
		}
	}
}
