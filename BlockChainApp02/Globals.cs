using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainApp02
{
	public static class Globals
	{
		//The binary file that stores the blockchain:
		public const String BLOCKCHAIN_XML_FILE_PATH = @"c:\temp\";
		public const String BLOCKCHAIN_XML_FILE_NAME = @"blockchain.xml";

		//Maximum blocks in our blockchain
		public const int MAX_NUM_OF_BLOCKS = 5; //EVENTUALLY REMOVE THIS! The blockchain should grow indefinitely

		//Transactions per block
		public const int NUM_OF_TXNS_PER_BLOCK = 10; //EVENTUALLY IMPROVE THIS! Should we really limit by #? Or would size be smarter?

	}
}
