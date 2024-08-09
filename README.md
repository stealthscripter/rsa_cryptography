# RSA Encryption Console Application

This repository contains a simple C# console application that demonstrates RSA encryption and decryption using the `RSACryptoServiceProvider` class.

## Overview

The application includes a class `RsaEnc` which handles the encryption and decryption of text using RSA (Rivest-Shamir-Adleman) public-key cryptography. The program allows you to:

- Generate a public/private key pair.
- Serialize and display the public key as an XML string.
- Encrypt a given plaintext string using the public key.
- Decrypt the encrypted string (cypher text) using the private key.

## Class Details

### `RsaEnc` Class

- **Constructor**: Initializes the RSA keys, exporting both the private and public keys.
- **PublicKeyString**: Serializes and returns the public key as an XML string.
- **Encrypt(string plainText)**: Encrypts the provided plaintext using the public key and returns the encrypted text in Base64 format.
- **Decrypt(string cypherText)**: Decrypts the provided cypher text using the private key and returns the original plaintext.

### `Program` Class

- The `Main` method:
  - Instantiates the `RsaEnc` class.
  - Displays the public key.
  - Prompts the user to input a text string to encrypt.
  - Encrypts the user input and displays the encrypted (cypher) text.
  - Decrypts the cypher text and displays the original plaintext.

## Usage

To run the application:

1. Clone the repository.
2. Build and run the project.
3. Follow the prompts to enter the text you wish to encrypt.
4. View the encrypted text.
5. Decrypt the text to verify the output.
