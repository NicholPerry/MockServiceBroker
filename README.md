# Mock Service Broker

The Mock Service Broker is designed to simulate requests originating from a Prima Power machine (the client). This broker is intended to replicate the interactions and signal exchanges as outlined in the provided sequence diagram and signal exchange documentation from Prima Power.

## Overview

The service broker enables effective testing and simulation of machine-client communications without requiring a live Prima Power machine. This facilitates easier testing, debugging, and validation of different scenarios.

## Key Features

- Simulates client requests and interactions based on Prima Power specifications.
- Follows the predefined sequence diagram for realistic behavior.
- Can be easily integrated and tested with compatible client simulators.

## Client Simulator

In addition to UI interaction, the Mock Service Broker has been thoroughly tested using a dedicated Client Simulator. This simulator can be accessed via the following GitHub repository:
`https://github.com/hadiscada/modbushd`

## Usage Guidelines

- Ensure that the sequence diagram and signal exchange details from Prima Power are properly reviewed.
- Download and set up the Client Simulator from the provided repository.
- Initiate requests and observe the behavior of the Mock Service Broker in response to the client interactions.
