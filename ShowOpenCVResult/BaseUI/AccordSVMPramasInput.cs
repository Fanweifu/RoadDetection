using System;
using System.Windows.Forms;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace ShowOpenCVResult
{
    public partial class AccordSVMPramasInput : UserControl
    {
        MulticlassSupportVectorMachine ksvm;
        bool hasTrained = false;

        public AccordSVMPramasInput()
        {
            InitializeComponent();
            cbStrategy.DataSource = Enum.GetValues(typeof(SelectionStrategy));
        }


        public double Complexity
        {
            get
            {
                return (double)numComplexity.Value;
            }
        }
        public double Tolerance
        {
            get
            {
                return (double)numTolerance.Value;
            }
        }
        public int CacheSize
        {
            get
            {
                return (int)numCache.Value;
            }
        }
        public SelectionStrategy Strategy
        {
            get
            {
                return SelectionStrategy.Sequential;
            }
        }

        public bool HasTrain { get { return hasTrained; } }

        public MulticlassSupportVectorMachine Svm { get { return ksvm; } }



        private IKernel createKernelFromPanel()
        {
            if (rbGaussian.Checked)
                return new Gaussian((double)numSigma.Value);
            if (numDegree.Value == 1)
                return new Linear((double)numConstant.Value);
            return new Polynomial((int)numDegree.Value, (double)numConstant.Value);
        }

        public void InitSVM(int arraysize,int classnums) {
            IKernel kernel = createKernelFromPanel();
            ksvm = new MulticlassSupportVectorMachine(arraysize, kernel, classnums);
        }


        public double Train(double[][] inputArray, int[] labels)
        {
            IKernel kernel = createKernelFromPanel();
            MulticlassSupportVectorLearning ml = new MulticlassSupportVectorLearning(ksvm, inputArray, labels)
            {
                Algorithm = (svm, classInputs, classOutputs, i, j) =>
                    new SequentialMinimalOptimization(svm, classInputs, classOutputs)
                    {
                        Complexity = Complexity,
                        Tolerance = Tolerance,
                        CacheSize = CacheSize,
                        Strategy = Strategy,
                        Compact = (kernel is Linear)
                    }
            };
            double error = ml.Run();
            hasTrained = true;
            return error;
        }

        public int Pridect(double[] inputarray, MulticlassComputeMethod method= MulticlassComputeMethod.Elimination) {
            if (!hasTrained) return -1;
            else {
                try
                {
                    return ksvm.Compute(inputarray, MulticlassComputeMethod.Elimination);
                }
                catch {
                    return -1;
                }
            }
        }

        public void LoadFile(string path) {
            ksvm = MulticlassSupportVectorMachine.Load(path);
            hasTrained = true;
        }

        public void ExportFile(string path)
        {
            if (hasTrained) {
                ksvm.Save(path);
            }
        }
    }
}
