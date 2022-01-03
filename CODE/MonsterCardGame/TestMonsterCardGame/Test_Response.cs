using MonsterCardGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame_TEST
{
    [TestFixture]
    class Test_Response
    {

        [Test]
        public void GetResponseTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(1, "My Message");

            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "1 My Message\n\r" +
                "\n");
            string request = getRq.ToString();
            res.GetResponse();

            Assert.AreEqual(request, res.responseMsg);
        }

        [Test]
        public void GetResponseIdTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(1, "My Message");
            res.allMsg.Add(2, "Some other Message");
            res.lastPart = "2";
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "some other Message\r\n" +
                "");
            string request = getRq.ToString();
            res.GetResponseId();

            Assert.AreEqual(request, res.responseMsg);
        }

        [Test]
        public void GetResponseMoreTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(1, "My Message");
            res.allMsg.Add(2, "Some other Message");

            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "1 My Message\n" +
                "2 Some other message\n\r" +
                "\n");
            string request = getRq.ToString();
            res.GetResponse();

            Assert.AreEqual(request, res.responseMsg);
        }

        [Test]
        public void ResponsePutTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(res.msgCounter, "My Message");
            res.lastPart = "1";
            res.ResponsePut();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Message ID: 1 is updated." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);
        }

        [Test]
        public void ResponsePostTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(res.msgCounter, "My Message");
            res.ResponsePost();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Message ID: 1" +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);
        }

        [Test]
        public void FailedResponseTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.ResponseFailed();
            getRq.Append(
                "HTTP/1.1 404 Not Found\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Fehler\r\n" +
                "\r\n");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);
        }

        [Test]
        public void DeleteResponseIdTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(res.msgCounter, "My Message");
            res.ResponsePost();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Message ID: 1" +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);
        }
    }
}
