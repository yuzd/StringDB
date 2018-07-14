﻿namespace StringDB.Reader {

	internal interface IPart {

		/// <summary>The initial byte detected</summary>
		byte InitialByte { get; }

		/// <summary>position of this part</summary>
		long Position { get; }

		/// <summary>Where the next position will be</summary>
		long NextPart { get; }
	}

	internal struct Part : IPart {

		internal Part(byte initByte, long pos, long nextPart) {
			this.InitialByte = initByte;
			this.Position = pos;
			this.NextPart = nextPart;
		}

		public static Part Start { get; } = new Part(0x00, 8, 8);

		public byte InitialByte { get; }
		public long Position { get; }
		public long NextPart { get; }
	}

	internal struct PartIndexChain : IPart {

		internal PartIndexChain(byte initByte, long pos, long nextPart) {
			this.InitialByte = initByte;
			this.Position = pos;
			this.NextPart = nextPart;
		}

		public byte InitialByte { get; }
		public long Position { get; }
		public long NextPart { get; }
	}

	internal struct PartDataPair : IPart {

		internal PartDataPair(byte initByte, long pos, long dataPos, byte[] indexName, byte byteType) {
			this.InitialByte = initByte;
			this.Position = pos;
			this.NextPart = pos + sizeof(byte) + sizeof(long) + (long)initByte + sizeof(byte);
			this.DataPosition = dataPos;
			this.Index = indexName;
			this.Type = byteType;
		}

		public long DataPosition;
		public byte[] Index;
		public byte Type;

		public byte InitialByte { get; }
		public long Position { get; }
		public long NextPart { get; }

		public IReaderPair ToReaderPair(RawReader rawReader)
			=> new ReaderPair(this.DataPosition, this.Position, this.Index, this.InitialByte, this.Type, rawReader);
	}
}