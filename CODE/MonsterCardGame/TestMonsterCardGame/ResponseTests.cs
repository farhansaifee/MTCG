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
    class ResponseTests
    {

        [Test]
        public void GetResponseTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(1, "Meine Nachricht");

            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "1 Meine Nachricht\n\r" +
                "\n");
            string request = getRq.ToString();
            res.GetResponse();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void GetResponseMoreTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(1, "Meine Nachricht");
            res.allMsg.Add(2, "was anderes");

            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "1 Meine Nachricht\n" +
                "2 was anderes\n\r" +
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

            res.allMsg.Add(1, "Meine Nachricht");
            res.allMsg.Add(2, "was anderes");
            res.lastPart = "2";
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "was anderes\r\n" +
                "");
            string request = getRq.ToString();
            res.GetResponseId();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponsePostTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(res.msgCounter, "Meine Nachricht");
            res.ResponsePost();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Nachricht ID: 1" +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponsePutTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(res.msgCounter, "Meine Nachricht");
            res.lastPart = "1";
            res.ResponsePut();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Nachricht ID: 1 is updated." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseDeleteIdTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.allMsg.Add(1, "Meine Nachricht");
            res.allMsg.Add(2, "was anderes");
            res.lastPart = "2";
            res.ResponseDeleteId();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Nachricht ID: 2 is deleted." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseFailedTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.ResponseFailed();
            getRq.Append(
                "HTTP/1.1 404 Not Found\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Error\r\n" +
                "\r\n");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
    }
}
