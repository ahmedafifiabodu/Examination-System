# Exam System Using C#

A brief description of what this project does and who it's for.

## Overview

The system is built to accommodate the needs of both educators preparing students for exams and students seeking to assess their knowledge. It features practice and final exam modes, enabling users to either prepare for upcoming tests or engage in formal assessments. The platform's design is subject-agnostic, allowing for its application across a wide range of academic disciplines.

### Features

- **Multiple Question Types:** Supports true/false, single choice, and multiple choice questions.
- **Exam Modes:** Includes practice exams with answers for self-assessment and final exams for formal testing.
- **Subject Organization:** Allows for the categorization of questions by subject.
- **Instant Feedback:** Offers real-time answer evaluation during practice exams.
- **Intuitive User Interface:** Easy navigation through exams and questions.
- **Scalability:** Designed to easily incorporate additional subjects or question types.

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

Ensure you have the following installed before starting:
- .NET 6.0 SDK or later
- Visual Studio 2022 or any IDE supporting .NET development

### Installation

1. Clone the repository to your local machine.
2. Open the solution file (`ExamSystemUsingCSharp.sln`) in Visual Studio or your preferred IDE.
3. Restore the NuGet packages.
4. Build the solution.
5. Run the application.

## Usage

To use the Exam System Using C#, follow these steps:
1. Launch the application.
2. Select a subject from the list provided.
3. Choose between Practice Exam or Final Exam mode.
4. Answer the questions as they appear.
5. Submit your answers for evaluation (Final Exam mode) or review the correct answers (Practice Exam mode).

## Scripts Overview

### Core Components

- **[Exam.cs](#exam.cs-context):** Base class for handling exam logic, including timing, question display, and score calculation.
- **[Final Exam.cs](#final-exam.cs-context):** Specialized class for final exams, focusing on question presentation without showing correct answers.
- **[Practical Exam.cs](#practical-exam.cs-context):** Derived class for practice exams, includes functionality to display correct answers for self-assessment.
- **[Answer.cs](#answer.cs-context):** Represents a user's answer to a question, facilitating correctness evaluation.
- **[Subject.cs](#subject.cs-context):** Encapsulates a subject, holding a collection of questions related to that subject.

### Question Types

- **[Question.cs](#question.cs-context):** Abstract base class for questions, defining common properties and methods.
- **[True - False.cs](#true---false.cs-context):** Implements true/false questions.
- **[Choose One Answer.cs](#choose-one-answer.cs-context):** Handles questions where only one answer is correct.
- **[Choose Multiple Answers.cs](#choose-multiple-answers.cs-context):** Manages questions allowing multiple correct answers.

### Program Entry

- **[Program.cs](#program.cs-context):** The entry point of the application, orchestrating the exam process.

## Contributing

We welcome contributions from the community. Whether it's bug fixes, feature additions, or improvements to documentation, your help is appreciated.

Please refer to [CONTRIBUTING.md](#) for our contribution guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- A heartfelt thank you to all educators and students who provided feedback.
- Gratitude to the .NET community for their resources and support.
- Inspired by the ongoing need for effective and accessible educational tools.