using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    // Class should have only one reason to Change.
    // Every class should have the responsibility of only one functionality (Encapsulated).

    // Impact of not following
    // 1. Maintainance will become complex.
    // 2. Understanding will be difficult for new Developers.
    // 3. Testability will be difficult

    // Reasons to follow
    // 1. Helps in following TDD
    // 2. Encourages Parallel Development.
    // 3. Loose Coupling.



    // Problem Statement
    interface IEmployee
    {
        /// <summary>
        /// Gets the Salary of an Employee
        /// </summary>
        /// <returns></returns>
        int GetSalary();

        /// <summary>
        /// Number of Hours worked by Employee
        /// </summary>
        /// <returns></returns>
        double HoursWorked();

        /// <summary>
        /// Logs Error if any
        /// </summary>
        /// <param name="errorMessage"></param>
        void LogError(string errorMessage);

        /// <summary>
        /// Perform Sending Email functionality
        /// </summary>
        /// <param name="emailSubject"></param>
        /// <param name="toEmail"></param>
        /// <param name="FromEmail"></param>
        void SendEmail(string emailSubject, string toEmail, string FromEmail);
    }



    // Solution

    interface IEmployeeSol
    {
        /// <summary>
        /// Gets the Salary of an Employee
        /// </summary>
        /// <returns></returns>
        int GetSalary();

        /// <summary>
        /// Number of Hours worked by Employee
        /// </summary>
        /// <returns></returns>
        double HoursWorked();
    }

    interface ILogger
    {
        /// <summary>
        /// Logs Error if any
        /// </summary>
        /// <param name="errorMessage"></param>
        void LogError(string errorMessage);
    }

    interface IEmail
    {
        /// <summary>
        /// Perform Sending Email functionality
        /// </summary>
        /// <param name="emailSubject"></param>
        /// <param name="toEmail"></param>
        /// <param name="FromEmail"></param>
        void SendEmail(string emailSubject, string toEmail, string FromEmail);
    }
}
