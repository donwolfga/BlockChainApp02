using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace BlockChainApp02
{
	[Serializable]
	public class Block
	{
		//This simple block is composed of five fields:
		//	Index - not really needed, and not really used, it's simply an index from 0 to the # of blocks
		//	HashPreviousBlock - the most important piece, which ties this all together is the hash of the previous block
		//	DateTime - not really needed, and not really used, it's simply the timestamp captured at time of creation
		//	Data - not really needed, and not really used, it's simply populated with garbage data in each block
		//	HashThisBlock - the most important piece, which ties this all together, is the hash of this block

		public int Index { get; set; }
		public string HashPreviousBlock { get; set; }
		public DateTime Timestamp { get; set; }
		public string Data { get; set; }
		public string HashThisBlock { get; set; }

		private byte[] ByteArraySource { get; set; }
		public byte[] ByteArrayHash { get; set; }

		public void HashAppendedFields()
		{
			//Concatenate all the fields in the block into a single string, and convert to a byte array:
			ByteArraySource = ASCIIEncoding.ASCII.GetBytes(Index.ToString() + HashPreviousBlock + Timestamp + Data);

			//Use SHA256 encryption (the encryption used in bitcoin) to hash the string:
			ByteArrayHash = new SHA256Managed().ComputeHash(ByteArraySource);
		}

		public void CreateGenesisBlock()
		{
			Index = 0;
			HashPreviousBlock = "0";
			Timestamp = DateTime.Now;
			Data = "Genesis Block";
			HashThisBlock = "";
		}

	}
}
