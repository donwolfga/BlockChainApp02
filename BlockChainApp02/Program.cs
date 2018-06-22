using System;
using System.Threading;

namespace BlockChainApp02
{
    class Program
    {
        static void Main(string[] args)
		{
			//This  program creates a simple blockchain, by loading an in-memory array of objects (blocks) from an XML file
			Console.WriteLine("BlockChainCreator version 2.0");
			
			//Create the in-memory blockchain:
			BlockChain BC = new BlockChain();

			//For demo purposes, create and load 5 (mostly) empty blocks:
			Console.WriteLine("Creating new blockchain");
			for (int i = 1; i < Globals.MAX_NUM_OF_BLOCKS; i++)
			{
				BC.Blockchain[i].Index = i;
				BC.Blockchain[i].Timestamp = DateTime.Now;
				BC.Blockchain[i].Data = "and the cow jumped over the moon";
				BC.Blockchain[i].HashPreviousBlock = BC.Blockchain[i - 1].HashThisBlock;
				BC.Blockchain[i].HashAppendedFields();
				BC.Blockchain[i].HashThisBlock = Utility.ByteArrayToString(BC.Blockchain[i].ByteArrayHash);

				Console.WriteLine("Block created with the following:");
				Console.WriteLine("Block index = " + BC.Blockchain[i].Index);
				Console.WriteLine("Block HashPreviousBlock = " + BC.Blockchain[i - 1].HashThisBlock); //Note we get hash of previous block in array
				Console.WriteLine("Block timestamp = " + BC.Blockchain[i].Timestamp);
				Console.WriteLine("Block data = " + BC.Blockchain[i].Data);
				Console.WriteLine("Block hash = " + BC.Blockchain[i].HashThisBlock + " (hash string length = " + BC.Blockchain[i].HashThisBlock.Length + ")");

				Console.ReadKey();
			}

			Console.WriteLine("A " + Globals.MAX_NUM_OF_BLOCKS + " block blockchain has been created");

			// Create an array to store transactions:
			Console.WriteLine("Creating an array of " + Globals.NUM_OF_TXNS_PER_BLOCK + " tranasactions");
			Transaction[] TransactionArray = new Transaction[Globals.NUM_OF_TXNS_PER_BLOCK];

			//Initialize/populate the transaction array with transaction objects:
			for (int i = 0; i < Globals.NUM_OF_TXNS_PER_BLOCK; i++)
			{
				TransactionArray[i] = new Transaction();
			}
			Console.WriteLine("Empty array of " + Globals.NUM_OF_TXNS_PER_BLOCK + " tranasactions created.");

			//Start listening on TCP port
			Console.WriteLine("Creating listener");
			TCPListener DonsListener = new TCPListener();
			

			//JUST FINISHED HERE. I need to add the "add transaction" logic
			//Thread th = new Thread(new ThreadStart(StartListen));
			//th.Start();

			
			//Finish with output
			Console.WriteLine("Press any key to write the blockchain to file and close");
			Console.ReadKey();

			//Write the blockchain to an XML file on the hard-drive:
			Utility.WriteBlockchainToXMLFile(Globals.BLOCKCHAIN_XML_FILE_PATH + Globals.BLOCKCHAIN_XML_FILE_NAME, BC.Blockchain);

			//Close the Listener:
			DonsListener.myListener.Stop();
			
		}
		


	}
}
