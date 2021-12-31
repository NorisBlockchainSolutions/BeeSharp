# BeeSharp - Connecting Hive to Enterprise Applications
## Warning - This version of BeeSharp is an alpha release. Do not use for production environments!
BeeSharp is a .Net 5 C# Library that integrates 
the Hive Blockchain to your project solutions.

## Technical Details
  - Support for multiple API Nodes and load balancing (WIP)
  - Auto API Node switching in case of simple API Node errors
  - Built using dependency inversion for custom requirements
  - Easily extendable by your own modules
  - Hive-Engine support (WIP, see BeeSharp.HiveEngine)
  - Read and Broadcast (WIP) blockchain data
  - Statically typed Api components for code completion & easy usage
  - Unit test covered code
  - Debug info available by event
  - Access deeply nested blockchain information by events and/or downcasting

## Installation / Getting Started
BeeSharp is built using a design strategy called dependency inversion.
This requires you to first assemble BeeSharp before actual usage.

But don't worry, assembling BeeSharp is easy and only requires 4 Steps!

  1. Clone/Download this repository, as well as the BeeSharpDefaultInitializer project.
  2. Add both projects to your existing solution.
  3. Create a BeeSharp configuration with BeeSharpDefaultInitializer > CondenserFactoryOptionsModel
  4. In BeeSharpDefaultInitializer, you will also find a CondenserAdapter.
Create an instance of CondenserAdapter, providing your configuration.

That's it! You can now use your instance of CondenserAdapter to interact with the Hive Blockchain!

(For more information on what the configuration values configure and how to continue from here on,
consult this projects Wiki.)

## Documentation
For further information, look at the specific components and
their documentation, as well as the Wiki attached to this
repository.

## Dependencies
BeeSharp uses the following libraries:
 - [BouncyCastle.NetCore](https://www.bouncycastle.org/csharp/)
 - [SimpleBase](https://github.com/ssg/SimpleBase)