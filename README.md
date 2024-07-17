![GitHub Super-Linter](https://github.com/UK-SBCoA/uniform-data-set-dotnet-web/actions/workflows/super-linter.yml/badge.svg) ![UDS.Net.Forms Unit Tests](https://github.com/UK-SBCoA/uniform-data-set-dotnet-web/actions/workflows/unit-tests.yml/badge.svg)
# UDS for .NET - Web app

This repository includes a frontend to electronically collect data for UDS including

* UDS instruments as HTML forms (additionally, packaged with Nuget to include in your own .NET project)
* .NET Core MVC web application
* Service layer to use with a companion [web API](https://github.com/UK-SBCoA/uniform-data-set-dotnet-api)
* Builds for Docker image [![Docker image build](https://github.com/UK-SBCoA/uniform-data-set-dotnet-web/actions/workflows/container-release.yml/badge.svg?branch=release)](https://github.com/orgs/UK-SBCoA/packages/container/package/uniform-data-set-dotnet-web)

This software is intended for use by [National Institute on Aging (NIA) Alzheimer's Disease Research Centers](https://www.nia.nih.gov/research/dn/national-alzheimers-coordinating-center-nacc) (ADRCs) to collect data for submission to the National Alzheimer's Coordinating Center ([NACC](https://naccdata.org/)) database. This data set is called UDS (Uniform Data Set). All ADRC's submit this data to contribute to the NIA's Alzheimer's Disease Longitudinal Study.

The software is implemented with several .NET tools and includes a development container for ease of use. You may choose to use the provided container or simply deploy the production container to your cloud storage provider. [More documentation can be found in our wiki.](https://github.com/UK-SBCoA/uniform-data-set-dotnet/wiki)

## Contributing
Thank you for interest in contributing to our project! There are many ways you can help:
* Submit bugs and feature requests [here](Discussions)
* Submit a fix by forking and submitting a PR Request [here](CONTRIBUTING.md)
* This solution includes automated tooling for linting, unit testing, and end-to-end testing. Powershell is required. Read more in our [wiki](https://github.com/UK-SBCoA/uniform-data-set-dotnet/wiki)

## Security
[Security reports](SECURITY.md)

## Feedback
* Request a [new feature](Discussions)
* Submit a [bug report](Issues)
* [Upvote](Discussions) popular feature requests

Read our [wiki](https://github.com/UK-SBCoA/uniform-data-set-dotnet/wiki) for more detailed information on each of these topics.

## License
The forms included in this repository are copyrighted. Detailed copyright statements and usage restrictions are available on each form and on [NACC](https://naccdata.org/data-collection/guidelines-copyright). Non-ADRC researchers who wish to use the forms in this repository should [complete and return a permission request](https://files.alz.washington.edu/nacc-permission-form.pdf).

Code in this repository is Copyright (c) University of Kentucky Sanders-Brown Center on Aging. All rights reserved. Licensed under the BSD 2-Clause "Simplified" License.
