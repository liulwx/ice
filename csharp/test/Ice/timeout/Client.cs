// **********************************************************************
//
// Copyright (c) 2003-2018 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

namespace Ice
{
    namespace timeout
    {
        public class Client : global::Test.TestHelper
        {
            public override void run(string[] args)
            {
                var properties = createTestProperties(ref args);

                //
                // For this test, we want to disable retries.
                //
                properties.setProperty("Ice.RetryIntervals", "-1");

                //
                // This test kills connections, so we don't want warnings.
                //
                properties.setProperty("Ice.Warn.Connections", "0");

                //
                // Limit the send buffer size, this test relies on the socket
                // send() blocking after sending a given amount of data.
                //
                properties.setProperty("Ice.TCP.SndSize", "50000");
                properties.setProperty("Ice.Package.Test", "Ice.timeout");
                using(var communicator = initialize(properties))
                {
                    AllTests.allTests(this);
                }
            }

            public static int Main(string[] args)
            {
                return global::Test.TestDriver.runTest<Client>(args);
            }
        }
    }
}
