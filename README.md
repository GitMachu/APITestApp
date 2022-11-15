# APITestApp
A RestSharp API script running tool

A tool to run scripts which contain REST requests and assertions.

Scripts are in XML format and are displayed upon opening the app. 3 scripts have been created that correspond to each API test case.

The tool serves as a script creator and runner. Upon clicking Run API Script, the tool will interpret each step in the grid and sends a request or performs an assertion between two values accordingly.

A status logs window will appear when running, which allows users to see what the tool is currently doing.

Execution will stop immediately if a step fails. A step fails if either a request fails to receive a correct response, or if an assertion is incorrect.

After a script run, a results window will appear, showing users whether a step passed, failed, or got skipped. Users can also look at the status logs during and after execution for more details.
