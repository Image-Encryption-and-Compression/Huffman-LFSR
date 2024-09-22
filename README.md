<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Link to Google Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap">
</head>

<h1 style="font-family:poppins;" align="center">
    Huffman-LFSR<br>
    Image Encryption and Compression
</h1>

<p style="font-family:poppins;" align="center">
    Securing and Compressing Images with Huffman Coding and Linear Feedback Shift Register (LFSR) Technique.
</p>

<div align="center">
    <img src="https://i.imgur.com/FeYzEgj.png" alt="Huffman-LFSR program">
</div>

## Overview
The **Huffman-LFSR Image Encryption and Compression** project integrates Huffman coding for efficient image compression with Linear Feedback Shift Register (LFSR) for secure encryption. This tool transforms `.bmp` images into compressed `binary files`, including necessary metadata for easy decompression and decryption.

Users can customize encryption parameters for added security, while the project includes benchmarks to assess performance in terms of speed and file size.

## Features
- **Huffman Tree Construction**: Builds a Huffman tree for each color channel and extracts corresponding Huffman codes based on the constructed tree based on the histogram of this color channel.
- **Image Compression**: Compresses `.bmp` images into a `.bin` file, which contains metadata about the Huffman trees and the compressed image data.
- **Image Encryption**: Provides functionality to encrypt `.bmp` images using LFSR.
- **Customizable Encryption Parameters**: Allows user to input any `initial seed` and `shift position` for the encryption process.
- **Image Decryption**: Decrypts the image using the `same initial` seed and `shift position` used during encryption.
- **Image Decompression**: Decompresses images using the saved metadata in the `.bin` file, restoring them back to `.bmp` format.
- **Complexity Analysis**: Offers a detailed complexity analysis using $\LaTeX$<br>
<br>

![Priority Queue operations Complexity Analysis](https://i.imgur.com/8R3xNKN.png)

## Extra Feature: Enhanced Alpha Numeric Key Generation

### What is it?
The AlphaLFSR class generates secure alphanumeric keys using a Linear Feedback Shift Register (LFSR) approach. It allows users to input a seed string containing numbers, symbols, and letters, which are then converted into a binary representation for robust encryption. The `tapPosition` parameter enables customized encryption enhancing randomness in the generated keys.

### Advantages
- **Increased Key Space**: Alphanumeric keys have a larger key space than binary (only 0,1) keys, making them more resistant to brute-force attacks.
- **User-Friendly**: These keys are easier to remember and input by users.
- **Reduced Collision Probability**: The diversity of characters minimizes the key collisions, enhancing overall security.
- **Enhanced Security**: The combination of a larger key space and alphanumeric diversity boosts security for encryption processes.

## Binary File Details
When compressing an image into a .bin file, metadata is saved to facilitate the recovery of the original image during the decompression process. Below is an overview of the file structure and its contents:
```plaintext
File structure:
    seed (int32) tapPosition(byte)
    Red Channel Tree {EOT=2}
    Green Channel Tree {EOT=2}
    Blue Channel Tree
    {EOH=3}
    height width
    image[0,0].red image[0,0].green image[0,0].blue image[0,1].red...
------------------------------------------------------------------------
Tree structure in the file:
    - pre-order traversal
    - 0: internal node, 1: leaf node, 2: end of the tree
    - All bytes
    - End it with 2
------------------------------------------------------------------------
Image structure in the file:
    - Concatenating each 8 bits into one byte
```

## Usage
![Huffman-LFSR program](https://i.imgur.com/FeYzEgj.png)

### Forward Operations (Encryption/Compression)
- Open **the desired image** to compress/encrypt
- Provide the `initial seed` and `tap position` (default=0)
- Click on the desired option
- Results show on left
- Save bin/image if you want


### Backward Operations (Decryption/Decompression)
- Open **binary image/file**
- Provide the `initial seed` and `tap position` (default=0)
- Click on the desired option
- Results show on left
- Save bin/image if you want


## Benchmarks
The following benchmarks illustrate the performance and efficiency of the image encryption and compression process. The graph. Analyzing these benchmarks helps to assess the effectiveness of the implemented algorithms.

## Benchmarks

### Time Benchmark (in seconds)
<table>
    <thead>
        <tr>
            <th align="center">Level</th>
            <th align="center">Encryption + Compression Time</th>
            <th align="center">Decryption + Decompression Time</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td align="center">Small 1</td>
            <td align="center">  0.040</td>
            <td align="center">  0.022</td>
        </tr>
        <tr>
            <td align="center">Small 2</td>
            <td align="center">  0.187</td>
            <td align="center">  0.140</td>
        </tr>
        <tr>
            <td align="center">Medium 1</td>
            <td align="center">  3.015</td>
            <td align="center">  2.250</td>
        </tr>
        <tr>
            <td align="center">Medium 2</td>
            <td align="center">  6.888</td>
            <td align="center">  5.491</td>
        </tr>
        <tr>
            <td align="center">Large 1</td>
            <td align="center"> 39.361</td>
            <td align="center"> 29.516</td>
        </tr>
        <tr>
            <td align="center">Large 2</td>
            <td align="center"> 68.548</td>
            <td align="center"> 54.048</td>
        </tr>
    </tbody>
</table>

### Size Benchmark (in bytes)
<table>
    <thead>
        <tr>
            <th align="center">Level</th>
            <th align="center">Bin File Size without Encryption</th>
            <th align="center">Ratio without Encryption</th>
            <th align="center">Bin File Size with Encryption</th>
            <th align="center">Ratio with Encryption</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td align="center">Small 1</td>
            <td align="center">   60,216</td>
            <td align="center">   1.223</td>
            <td align="center">   75,630</td>
            <td align="center">   0.973</td>
        </tr>
        <tr>
            <td align="center">Small 2</td>
            <td align="center">  189,104</td>
            <td align="center">   3.967</td>
            <td align="center">  189,095</td>
            <td align="center">   3.967</td>
        </tr>
        <tr>
            <td align="center">Medium 1</td>
            <td align="center">8,044,705</td>
            <td align="center">   0.187</td>
            <td align="center">9,439,488</td>
            <td align="center">   1.00</td>
        </tr>
        <tr>
            <td align="center">Medium 2</td>
            <td align="center">15,187,698</td>
            <td align="center">   0.545</td>
            <td align="center">21,504,421</td>
            <td align="center">   1.157</td>
        </tr>
        <tr>
            <td align="center">Large 1</td>
            <td align="center">97,047,824</td>
            <td align="center">   1.364</td>
            <td align="center">124,878,942</td>
            <td align="center">   1.06</td>
        </tr>
        <tr>
            <td align="center">Large 2</td>
            <td align="center">195,185,524</td>
            <td align="center">   1.101</td>
            <td align="center">195,185,515</td>
            <td align="center">   1.101</td>
        </tr>
    </tbody>
</table>
