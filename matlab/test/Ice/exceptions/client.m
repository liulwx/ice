%{
**********************************************************************

Copyright (c) 2003-2018 ZeroC, Inc. All rights reserved.

This copy of Ice is licensed to you under the terms described in the
ICE_LICENSE file included in this distribution.

**********************************************************************
%}

function client(args)
    addpath('generated');
    if ~libisloaded('ice')
        loadlibrary('ice', @iceproto)
    end

    helper = TestHelper();
    properties = helper.createTestProperties(args);
    properties.setProperty('Ice.Warn.Connections', '0');
    properties.setProperty('Ice.MessageSizeMax', '10'); % 10KB max
    communicator = helper.initialize(properties);
    cleanup = onCleanup(@() communicator.destroy());

    thrower = AllTests.allTests(helper);
    thrower.shutdown();

    clear('classes'); % Avoids conflicts with tests that define the same symbols.
end
