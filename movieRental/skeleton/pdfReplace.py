from PyPDF2 import PdfReader, PdfWriter

# Paths to the files
input_pdf_path = "input.pdf"          # The original multi-page PDF
replacement_pdf_path = "replace.pdf"  # The single-page PDF
output_pdf_path = "output.pdf"        # The result PDF

# Read the original and replacement PDFs
input_reader = PdfReader(input_pdf_path)
replacement_reader = PdfReader(replacement_pdf_path)

# Ensure the replacement PDF has exactly one page
if len(replacement_reader.pages) != 1:
    raise ValueError("The replacement PDF must have exactly one page.")

# Create a writer for the output PDF
output_writer = PdfWriter()

# Specify the page number to replace (1-based index)
replace_page_number = 2  # Replace the second page

# Loop through the pages of the original PDF
for i in range(len(input_reader.pages)):
    if i == replace_page_number - 1:
        # Add the page from the replacement PDF
        output_writer.add_page(replacement_reader.pages[0])
    else:
        # Add the page from the original PDF
        output_writer.add_page(input_reader.pages[i])

# Write the result to a new PDF
with open(output_pdf_path, "wb") as output_file:
    output_writer.write(output_file)

print(f"Page {replace_page_number} replaced successfully!")
