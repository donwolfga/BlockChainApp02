using System;
using System.Collections.Generic;

using System.Text;
using System.IO;


namespace BlockChainApp02
{
	[Serializable]
	class BlockChain
	{
		//Create an array to store the (NumOfBlocks) blocks:
		public Block[] Blockchain = new Block[Globals.MAX_NUM_OF_BLOCKS];

		//Initialize the blockchain:
		public BlockChain()
		{

			//Initialize/populate the blockchain array with block objects:
			for (int i = 0; i < Globals.MAX_NUM_OF_BLOCKS; i++)
			{
				Blockchain[i] = new Block();
			}

			//Check if the blockchain file has already been created and stored locally on the hard-drive:
			if (File.Exists(Globals.BLOCKCHAIN_XML_FILE_PATH + Globals.BLOCKCHAIN_XML_FILE_NAME))
			{
				Console.WriteLine("Blockchain file exists. Loading it into memory...");

				//Load the blockchain from the file
				Utility.ReadBlockchainFromXMLFile(Globals.BLOCKCHAIN_XML_FILE_PATH + Globals.BLOCKCHAIN_XML_FILE_NAME, Blockchain);
			}
			else
			{
				Console.WriteLine("Blockchain file does not exist; therefore, we're creating a new blockchain...");

				//Since the blockchain file does not exist, create a new one, and create the Genesis block:
				Blockchain[0].CreateGenesisBlock();
				Blockchain[0].HashAppendedFields();
				Blockchain[0].HashThisBlock = Utility.ByteArrayToString(Blockchain[0].ByteArrayHash);
			}

		}

	}
}
	

