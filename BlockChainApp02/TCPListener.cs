using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace BlockChainApp02
{
	class TCPListener 
	{
		public TcpListener myListener;
		private int port = 5050;  // Arbitrarily chose port 5050, but can choose any open port 

		//The constructor which make the TcpListener start listening on the given port. 
		//It also calls a Thread on the method StartListen(). 
		public TCPListener() 
		{
			try
			{
				//Hardcode the IP address to the local machine
				IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

				//Start listening
				myListener = new TcpListener(ipAddress, port);
				myListener.Start();

				//start the thread which calls the method 'StartListen'
				Thread th = new Thread(new ThreadStart(StartListen));
				th.Start();
				
			}
			catch (Exception e)
			{
				Console.WriteLine("An Exception occurred while Listening :" + e.ToString());
			}
		}

		public void StartListen()
		{
			while (true)
			{
				//Accept a new connection
				Socket mySocket = myListener.AcceptSocket();

				if (mySocket.Connected)
				{
					//Example input to this socket via a browser URL:
					//127.0.0.1:5050/FromAddress=A12B3C,ToAddress=122333444,Amount=985.50
					
					//Define the transaction fields which include the from-address, to-address, and amount
					string strFromParm = "FromAddress=";
					string strToParm = "ToAddress=";
					string strAmtParm = "Amount=";

					string strFromAddress;
					string strToAddress;
					string strAmt;
					int intStart;
					int intEnd;
					
					//make a byte array and receive data from the client 
					Byte[] bReceive = new Byte[1024];
					int i = mySocket.Receive(bReceive, bReceive.Length, 0);

					//Convert Byte to String
					string sBuffer = Encoding.ASCII.GetString(bReceive);

					//Display the entire input buffer for debugging purposes:
					//Console.WriteLine("sBuffer = " + sBuffer);

					//Confirm the input string has the three required fields
					if (sBuffer.IndexOf(strFromParm) > 0 && sBuffer.IndexOf(strToParm) > 0 && sBuffer.IndexOf(strAmtParm) > 0) {
						//Within the input string, parse out the from-address, to-address, and amount
						//from-address:
						intStart = sBuffer.IndexOf(strFromParm) + strFromParm.Length;
						intEnd = sBuffer.IndexOf(strToParm);
						strFromAddress = sBuffer.Substring(intStart, intEnd - intStart - 1);

						//to-address:
						intStart = sBuffer.IndexOf(strToParm) + strToParm.Length;
						intEnd = sBuffer.IndexOf(strAmtParm);
						strToAddress = sBuffer.Substring(intStart, intEnd - intStart - 1);

						//Amt:
						intStart = sBuffer.IndexOf(strAmtParm) + strAmtParm.Length;
						intEnd = sBuffer.IndexOf("HTTP");
						strAmt = sBuffer.Substring(intStart, intEnd - intStart - 1);

						Console.WriteLine("FromAddress = " + strFromAddress);
						Console.WriteLine("ToAddress = " + strToAddress);
						Console.WriteLine("Amount = " + strAmt);
						BC[0].
					}
					else {

						//Output an error message about the missing parm(s):
						Console.WriteLine("Wrong input parms");

						if (sBuffer.IndexOf(strFromParm) == -1) {
							Console.WriteLine("Missing FromAddress");
						}
						if (sBuffer.IndexOf(strToParm) == -1)
						{
							Console.WriteLine("Missing ToAddress");
						}
						if (sBuffer.IndexOf(strAmtParm) == -1)
						{
							Console.WriteLine("Missing Amount");
						}

					}

					mySocket.Close();
				}
			}
		}
	}
}
