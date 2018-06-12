﻿using StringDB.Inoperable;
using System.Collections;
using System.Collections.Generic;

namespace StringDB.Reader {
	/// <summary>Inoperable class. Any method called will throw an InoperableException.</summary>
	public class InoperableReader : IReader, IInoperable {
		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public ulong GetOverhead() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public bool Empty() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public IReaderInteraction FirstIndex() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public IReaderInteraction LastIndex() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public IEnumerator<ReaderPair> GetEnumerator() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public byte[][] GetIndexes() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public IReaderChain GetReaderChain() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public byte[] GetValueOf(IReaderInteraction r, bool doSeek = false) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public byte[] GetValueOf(string index, bool doSeek = false, ulong quickSeek = 0) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public byte[][] GetValuesOf(IReaderInteraction r, bool doSeek = false) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public byte[][] GetValuesOf(string index, bool doSeek = false, ulong quickSeek = 0) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public IReaderInteraction IndexAfter(IReaderInteraction r, bool doSeek = false) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public IReaderInteraction IndexAfter(string index, bool doSeek = false, ulong quickSeek = 0) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public bool IsIndexAfter(IReaderInteraction r, bool doSeek = false) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public bool IsIndexAfter(string index, bool doSeek = false, ulong quickSeek = 0) => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		IEnumerator IEnumerable.GetEnumerator() => throw new InoperableException();

		/// <summary>Throws an InoperableException</summary><returns>Throws an InoperableException</returns>
		public byte[] GetDirectValueOf(ulong dataPos) => throw new InoperableException();

		/// <summary>Does absolutely nothing - doesn't even throw an inoperable exception. We *want* to go away, we're inoperable.</summary>
		public void Dispose() { }
	}
}