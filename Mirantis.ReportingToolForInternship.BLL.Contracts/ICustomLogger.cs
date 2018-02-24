namespace Mirantis.ReportingTool.BLL.Contracts
{
	using System;

	public interface ICustomLogger
    {
        void RecordError(Exception e);
		void RecordInfo(string info);
    }
}
